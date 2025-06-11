using System;
using Microsoft.EntityFrameworkCore;
using To_doListApp.Data;
using To_doListApp.Enums;
using To_doListApp.Models;

namespace To_doListApp.Repositories
{ //This file handles all the database operations 
    public class TaskRepository : ITaskRepository
    {
        private readonly TodoDbContext _context;

        public TaskRepository(TodoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskItem>> GetAllAsync(TodoStatus? status = null, TaskPriority? priority = null, DateTime? dueDate = null)
        {
            var query = _context.Tasks.AsQueryable();

            if (status.HasValue)
                query = query.Where(t => t.Status == status.Value);

            if (priority.HasValue)
                query = query.Where(t => t.Priority == priority.Value);

            if (dueDate.HasValue)
                query = query.Where(t => t.DueDate.HasValue && t.DueDate.Value.Date == dueDate.Value.Date);

            return await query.ToListAsync();
        }

        public async Task<TaskItem> GetByIdAsync(int id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public async Task<TaskItem> CreateAsync(TaskItem task)
        {
            await _context.Tasks.AddAsync(task); //add to the database
            await _context.SaveChangesAsync(); //save changes 
            return task; //retun the created task
        }

        public async Task<bool> UpdateAsync(TaskItem task)
        {
            // EF Core tracks changes automatically if the entity is already being tracked and that causes other other fields to reset even tho it was not modified 
            var result = await _context.SaveChangesAsync();
            return result > 0; // indicates success if more than 0 rows are affected
        }

        public async Task<bool> DeleteAsync(TaskItem task)
        {
            _context.Tasks.Remove(task);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
    //Repository handles only entities and data operations. automapper can't be used here 
}

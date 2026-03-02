using Microsoft.EntityFrameworkCore;
using TinyBoard.Web.Data;
using TinyBoard.Web.Models;

namespace TinyBoard.Web.Services;

public class CardService
{
    private readonly AppDbContext _db;
    public CardService(AppDbContext db) => _db = db;

    public Task<List<CardItem>> GetAllAsync() =>
        _db.Cards.OrderByDescending(c => c.CreatedAtUtc).ToListAsync();

    public async Task AddAsync(CardItem card)
    {
        card.CreatedAtUtc = DateTime.UtcNow;
        card.UpdatedAtUtc = DateTime.UtcNow;

        _db.Cards.Add(card);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateAsync(CardItem card)
    {
        card.UpdatedAtUtc = DateTime.UtcNow;

        _db.Cards.Update(card);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _db.Cards.FirstOrDefaultAsync(c => c.Id == id);
        if (entity is null) return;

        _db.Cards.Remove(entity);
        await _db.SaveChangesAsync();
    }
}
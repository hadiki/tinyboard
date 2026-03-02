using Microsoft.EntityFrameworkCore;
using TinyBoard.Web.Models;

namespace TinyBoard.Web.Data;

public static class DbSeeder
{
    public static async Task SeedAsync(AppDbContext db)
    {
        if (await db.Cards.AnyAsync()) return;
        
        db.Cards.AddRange(
            new CardItem { Title = "Welcome to TinyBoard", Notes = "Create, move, delete cards", Status = CardStatus.ToDo },
            new CardItem { Title = "Move me to Doing", Status = CardStatus.ToDo },
            new CardItem { Title = "Finish Sprint 1", Status = CardStatus.Doing },
            new CardItem { Title = "Add Dockerfile", Status = CardStatus.ToDo },
            new CardItem { Title = "Add GitHub Actions CI", Status = CardStatus.ToDo }
        );
        
        await db.SaveChangesAsync();
    }
}
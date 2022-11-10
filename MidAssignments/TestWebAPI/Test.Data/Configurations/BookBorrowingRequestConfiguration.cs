/*using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using Test.Data.Entities;

namespace Test.Data.Configurations
{
    public class BookBorrowingRequestConfiguration : IEntityTypeConfiguration<BookBorrowingRequest>
    {
        public void Configure(EntityTypeBuilder<BookBorrowingRequest> modelBuilder)
        {
            modelBuilder.ToTable("BookBorrowingRequest")
                        .HasKey(u => u.Id);

            modelBuilder.HasOne(b => b.RequestedBy)
                        .WithMany(r => r.BookBorrowingRequests)
                        .HasForeignKey(b => b.ProcessedByUserId)
                        .IsRequired();

            modelBuilder.HasOne(b => b.ProcessedBy)
                        .WithMany(r => r.ProcessedRequests)
                        .HasForeignKey(b => b.ProcessedByUserId)
                        .IsRequired(false);
        }
    }
}
*/
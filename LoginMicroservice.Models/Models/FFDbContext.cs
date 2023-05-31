using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LoginMicroservice.Models.Models;

public partial class FFDbContext : DbContext
{
    public FFDbContext()
    {
    }

    public FFDbContext(DbContextOptions<FFDbContext> options)
        : base(options)
    {

    }
    public virtual DbSet<Users> Users { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=MYSQL5044.site4now.net;Database=db_a9a28e_dungba;Uid=a9a28e_dungba;Pwd=Ad290399@;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

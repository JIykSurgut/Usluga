using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Usluga.Data.Models;


public class ChatEvent
{
    public int Id { get; set; }

    public int? IdChatEventParent { get; set; }

    public int? IdChatEventPrev { get; set; }

    public int? IdChatEventNext { get; set; }

    public string Text { get; set; } = null!;

    public DateTime DateInsert { get; set; }

    public DateTime DateUpdate { get; set; }

    public int IdEmployee { get; set; }

    public virtual ChatEvent? IdChatEventNextNavigation { get; set; }

    public virtual ChatEvent? IdChatEventParentNavigation { get; set; }

    public virtual ChatEvent? IdChatEventPrevNavigation { get; set; }

    public virtual Employee IdEmployeeNavigation { get; set; } = null!;

    public virtual ICollection<ChatEvent> InverseIdChatEventNextNavigation { get; set; } = new List<ChatEvent>();

    public virtual ICollection<ChatEvent> InverseIdChatEventParentNavigation { get; set; } = new List<ChatEvent>();

    public virtual ICollection<ChatEvent> InverseIdChatEventPrevNavigation { get; set; } = new List<ChatEvent>();
}

public class ChatEventEntityConfig : IEntityTypeConfiguration<ChatEvent>
{
    public void Configure(EntityTypeBuilder<ChatEvent> builder)
    {
        builder.ToTable("ChatEvent")
           .HasKey(e => e.Id)
           .HasName("PK_AD")
           .HasName("PK_ChatEvent_Id");

        builder.Property(e => e.Id)
            .HasColumnName("Id")
            .HasColumnType("int");


        

        builder.Property(e => e.IdChatEventNext)
            .HasColumnName("Id_ChatEvent_Next")
            .HasColumnType("int");

        builder.Property(e => e.IdChatEventParent)
            .HasColumnName("Id_ChatEvent_Parent")
            .HasColumnType("int");


        builder.Property(e => e.DateInsert)
            .HasColumnName("DateInsert")
            .HasColumnType("datetime");

        builder.Property(e => e.DateUpdate)
            .HasColumnName("DateUpdate")
            .HasColumnType("datetime");

        builder
            .HasOne(d => d.IdChatEventNextNavigation)
            .WithMany(p => p.InverseIdChatEventNextNavigation)
            .HasForeignKey(d => d.IdChatEventNext)
            .HasConstraintName("FK_ChatEvent_IdChatEvent_Next");

        builder
            .HasOne(d => d.IdChatEventParentNavigation)
            .WithMany(p => p.InverseIdChatEventParentNavigation)
            .HasForeignKey(d => d.IdChatEventParent)
            .HasConstraintName("FK_ChatEvent_IdChatEvent_Parent");

        builder
            .HasOne(d => d.IdChatEventPrevNavigation)
            .WithMany(p => p.InverseIdChatEventPrevNavigation)
            .HasForeignKey(d => d.IdChatEventPrev)
            .HasConstraintName("FK_ChatEvent_IdChatEvent_Prev");

        builder
            .HasOne(d => d.IdEmployeeNavigation)
            .WithMany(p => p.ChatEvents)
            .HasForeignKey(d => d.IdEmployee)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_ChatEvent_IdEmployee");
    }

}
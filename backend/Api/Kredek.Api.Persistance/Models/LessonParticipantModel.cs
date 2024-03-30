using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kredek.Api.Persistance.Models;

[Table("LessonParticipants", Schema = "KREDEK")]
public class LessonParticipantModel : BaseEntity
{
    public long Id { get; set; }
    public long LessonId { get; set; }
    public LessonModel Lesson { get; set; }
    public long ParticipantId { get; set; }
    public ParticipantModel Participant { get; set; }
}

public class LessonParticipantConfiguration : IEntityTypeConfiguration<LessonParticipantModel>
{
    public void Configure(EntityTypeBuilder<LessonParticipantModel> builder)
    {
        builder.HasKey(lp => lp.Id);
        builder.HasOne(lp => lp.Lesson)
            .WithMany(l => l.LessonParticipants)
            .HasForeignKey(lp => lp.LessonId);
        builder.HasOne(lp => lp.Participant)
            .WithMany(p => p.LessonParticipants)
            .HasForeignKey(lp => lp.ParticipantId);
    }
}

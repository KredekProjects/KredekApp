using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kredek.Api.Persistance.Models;

[Table("CourseParticipants", Schema = "KREDEK")]
public class CourseParticipantModel : BaseEntity
{
    public long Id { get; set; }
    public long CourseId { get; set; }
    public CourseModel Course { get; set; }
    public long ParticipantId { get; set; }
    public ParticipantModel Participant { get; set; }
}

public class CourseParticipantConfiguration : IEntityTypeConfiguration<CourseParticipantModel>
{
    public void Configure(EntityTypeBuilder<CourseParticipantModel> builder)
    {
        builder.HasKey(cp => cp.Id);
        builder.HasOne(cp => cp.Course)
            .WithMany(c => c.CourseParticipants)
            .HasForeignKey(cp => cp.CourseId);
        builder.HasOne(cp => cp.Participant)
            .WithMany(p => p.CourseParticipants)
            .HasForeignKey(cp => cp.ParticipantId);
    }
}

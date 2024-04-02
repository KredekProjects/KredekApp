using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kredek.Api.Persistance.Models;

[Table("Lessons", Schema = "KREDEK")]
public class LessonModel : BaseEntity
{
    public long Id { get; set; }
    public long CourseId { get; set; }
    public CourseModel Course { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public string Presenter { get; set; }
    public ICollection<LessonParticipantModel> LessonParticipants { get; set; }
}

public class LessonConfiguration : IEntityTypeConfiguration<LessonModel>
{
    public void Configure(EntityTypeBuilder<LessonModel> builder)
    {
        builder.HasKey(l => l.Id);
        builder.HasOne(l => l.Course)
            .WithMany(c => c.Lessons)
            .HasForeignKey(l => l.CourseId);
    }
}

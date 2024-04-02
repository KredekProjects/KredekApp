using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kredek.Api.Persistance.Models;

[Table("Courses", Schema = "KREDEK")]
public class CourseModel : BaseEntity
{
    public long Id { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string DriveFolderUrl { get; set; }
    public ICollection<CourseParticipantModel> CourseParticipants { get; set; }
    public ICollection<LessonModel> Lessons { get; set; }
}

public class CourseConfiguration : IEntityTypeConfiguration<CourseModel>
{
    public void Configure(EntityTypeBuilder<CourseModel> builder)
    {
        builder.HasKey(c=>c.Id);
    }
}

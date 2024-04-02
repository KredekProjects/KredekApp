using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kredek.Api.Persistance.Models;

[Table("Participants", Schema = "KREDEK")]
public class ParticipantModel : BaseEntity
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string GithubUrl { get; set; }
    public string GmailAddress { get; set; }
    public string CourseRepoUrl { get; set; }
    public ICollection<CourseParticipantModel> CourseParticipants { get; set; }
    public ICollection<LessonParticipantModel> LessonParticipants { get; set; }
}

public class ParticiantConfiguration : IEntityTypeConfiguration<ParticipantModel>
{
    public void Configure(EntityTypeBuilder<ParticipantModel> builder)
    {
        builder.HasKey(p => p.Id);
    }
}

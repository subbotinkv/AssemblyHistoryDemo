namespace AssemblyHistoryApp.DAL
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Common;

    /// <summary>
    /// �������� ��� �������� � �� ���������� � ��������� ����������.
    /// </summary>
    public class MemberAnnotationEntity
    {
        public MemberAnnotationEntity()
        {
            
        }

        public MemberAnnotationEntity(AssemblyMemberEntity member, HistoryAttribute historyAttribute)
        {
            if (member == null)
            {
                throw new ArgumentNullException(nameof(member));
            }
            if (historyAttribute == null)
            {
                throw new ArgumentNullException(nameof(historyAttribute));
            }

            DateTime = historyAttribute.DateTime;
            Author = historyAttribute.Author;
            Description = historyAttribute.Description;

            Member = member;
        }

        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(100)]
        public string Author { get; set; }

        [Required]
        public string Description { get; set; }

        public int MemberId { get; set; }

        public AssemblyMemberEntity Member { get; set; }
    }
}
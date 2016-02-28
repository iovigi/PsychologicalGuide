namespace PsychologicalGuide.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Contracts;
    
    public abstract class BaseModel<TKey> : IAuditInfo, ISoftDeletable
    {
        public BaseModel()
        {
            this.CreatedOn = DateTime.Now;
        }

        [Key]
        public TKey Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsDelete { get; set; }
    }
}

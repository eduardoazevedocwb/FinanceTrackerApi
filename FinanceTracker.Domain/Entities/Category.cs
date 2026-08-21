using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTracker.Domain.Entities
{
    public class Category
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; } = string.Empty;

        public bool IsActive { get; set; }
        
        private Category() { }

        public Category(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            IsActive = true;
        }
        
        public void UpdateName(string name)
        {
            Name = name;
        }
        public void Deactivate()
        {
            IsActive = false;
        }
    }
}

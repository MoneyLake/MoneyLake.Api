using System;

namespace MoneyLake.Api.DataAccess.DTO
{
    public class Operation
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TimeSpan SpentTime { get; set; }
        
        public string UserLogin { get; set; }
        public User User { get; set; }
        
        public int StatusId { get; set; }
        public OperationStatus Status { get; set; }
    }
}

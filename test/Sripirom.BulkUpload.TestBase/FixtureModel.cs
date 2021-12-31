using System;

namespace Sripirom.BulkUpload.TestBase
{
    public partial class FixtureModel
    {
        public abstract class BaseFixtureModel<TModel>
            where TModel : class
        {
            public TModel Object { get; set; }
        }

        public class CreateById
        {
            public CreateById(int id, DateTime createdDate)
            {
                Id = id;
                CreatedDate = createdDate;
            }

            public int Id { get; set; }
            public DateTime CreatedDate { get; set; }
        }
    }
}

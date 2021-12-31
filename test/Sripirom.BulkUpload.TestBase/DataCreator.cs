using Sripirom.BulkUpload.DataAccess.Context;

namespace Sripirom.BulkUpload.TestBase
{
    public partial class DataCreator
    {
        public BulkUploadDbContext Context { get; }

        public DataCreator(BulkUploadDbContext context)
        {
            Context = context;
        }

        public static DataCreator Building(BulkUploadDbContext context)
        {
            return new DataCreator(context);
        }
    }
}

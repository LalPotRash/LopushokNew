namespace LopushokNew.DB
{
    public partial class LopushokNewEntities
    {
        private static LopushokNewEntities _context;

        public static LopushokNewEntities GetContext()
        {
            if (_context == null)
                _context = new LopushokNewEntities();

            return _context;
        }
    }
}

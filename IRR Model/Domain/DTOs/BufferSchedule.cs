namespace IRR.Domain.DTOs
{
    public class BufferSchedule(int id, float BufferFactor, DateTime BufferDate)
    {

        private readonly int _id = id;
        private readonly float _bufferFactor = BufferFactor;
        private readonly DateTime _bufferDate = BufferDate;


        public int Id => _id;
        public float BufferFactor => _bufferFactor;

        public DateTime BufferDate => _bufferDate;


    }
}

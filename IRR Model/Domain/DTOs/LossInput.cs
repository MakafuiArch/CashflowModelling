using IRR.Domain.Model;

namespace IRR.Domain.DTOs
{
    public class LossInput(
        int LayerId,
        DateTime LayerInception, 
        DateTime OccurrenceDay, 
        double SubjectLoss,
        double ReinstPremium
        
        )
    {
        private readonly int _layerId = LayerId;
        private readonly DateTime _layerInception = LayerInception;
        private readonly DateTime _occurrenceDay = OccurrenceDay;
        private readonly double _subjectLoss = SubjectLoss;
        private readonly double _reinstPremium = ReinstPremium;

        
        public DateTime LayerInception => _layerInception;
        public DateTime OccurrenceDay => _occurrenceDay;
        public double SubjectLoss => _subjectLoss;
        public double ReinstPremium => _reinstPremium;


        public int LayerId => _layerId; 

    }
}

using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using System.Threading.Tasks;

namespace SimpleTrader.WPF.ViewModels {
    public class MajorIndexViewModel {
        public MajorIndex DowJones { get; set; }
        public MajorIndex Nasdaq { get; set; }
        public MajorIndex SP500 { get; set; }

        private readonly IMajorIndexService _majorIndexService;
        public MajorIndexViewModel(IMajorIndexService majorIndexService) {
            _majorIndexService = majorIndexService;
        }

        public MajorIndexViewModel() {
        }

        // Instansiates a MajorIndexViewModel, loads the data and returns it
        public static MajorIndexViewModel LoadMajorIndexViewModel(IMajorIndexService majorIndexService) {
            MajorIndexViewModel majorIndexViewModel = new MajorIndexViewModel(majorIndexService);
            majorIndexViewModel.LoadMajorIndexes();
            return majorIndexViewModel;
        }

        private void LoadMajorIndexes() {
            _majorIndexService.GetMajorIndex(MajorIndexType.DowJones).ContinueWith(task => {
                if(task.Exception == null) {
                    DowJones = task.Result;
                }
            });

            _majorIndexService.GetMajorIndex(MajorIndexType.Nasdaq).ContinueWith(task => {
                if (task.Exception == null) {
                    Nasdaq = task.Result;
                }
            });

            _majorIndexService.GetMajorIndex(MajorIndexType.SP500).ContinueWith(task => {
                if (task.Exception == null) {
                    SP500 = task.Result;
                }
            });
        }
    }
}

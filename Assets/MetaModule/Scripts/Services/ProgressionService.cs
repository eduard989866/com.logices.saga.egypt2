using Infrastructure.Settings;
using Match3Game.Settings;

namespace Infrastructure.Services
{
    public class ProgressionService : IInitializableService
    {
        private ConfigurationService _configurationService;
        private LevelsService _levelsService;
        private ProgressionSettings _progressionSettings;
        private TargetsSettings _targetsSettings;
        
        public void Initialize()
        {
            _configurationService = ServiceLocator.GetService<ConfigurationService>();
            _levelsService = ServiceLocator.GetService<LevelsService>();
            _progressionSettings = _configurationService.GetSettings<ProgressionSettings>();
            _targetsSettings = _configurationService.GetSettings<TargetsSettings>();
        }
        
        public int ProgressiveScoresCount()
        {
            return _progressionSettings.WinScores +
                   _progressionSettings.ProgressiveWinScores * (_levelsService.CurrentLevel - 1);
        }

        public int ProgressiveLevelTime()
        {
            return _progressionSettings.LevelTime +
                   _progressionSettings.ProgressiveLevelTime * (_levelsService.CurrentLevel - 1);
        }
        
        public int ProgressiveTargetsCount()
        {
            return _targetsSettings.InitialTargetsCount +
                   _targetsSettings.ProgressiveTargetsCount * (_levelsService.CurrentLevel - 1);
        }
    }
}
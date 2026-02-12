using NetAF.Events;
using NetAF.Logic;
using NetAF.Logic.Modes;
using NetAF.Persistence;
using NetAF.Persistence.Json;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace NetAF.Targets.WPF.Controls
{
    /// <summary>
    /// Interaction logic for NetAFFileManager.xaml
    /// </summary>
    public partial class NetAFFileManager : UserControl, IUpdatable
    {
        #region Fields

        private Game? game;

        #endregion

        #region Properties

        /// <summary>
        /// Get or set the path to the selected directory. This is a dependency property.
        /// </summary>
        public string SelectedDirectoryPath
        {
            get { return (string)GetValue(SelectedDirectoryPathProperty); }
            set { SetValue(SelectedDirectoryPathProperty, value); }
        }

        /// <summary>
        /// Get the game directory path. This is a dependency property.
        /// </summary>
        public string GameDirectoryPath
        {
            get { return (string)GetValue(GameDirectoryPathProperty); }
            private set { SetValue(GameDirectoryPathProperty, value); }
        }

        /// <summary>
        /// Get the status. This is a dependency property.
        /// </summary>
        public string Status
        {
            get { return (string)GetValue(StatusProperty); }
            private set { SetValue(StatusProperty, value); }
        }

        /// <summary>
        /// Get the available restore points. This is a dependency property.
        /// </summary>
        public ObservableCollection<RestorePointPath?> AvailableRestorePoints
        {
            get { return (ObservableCollection<RestorePointPath?>)GetValue(AvailableRestorePointsProperty); }
            private set { SetValue(AvailableRestorePointsProperty, value); }
        }

        /// <summary>
        /// Get if save and load is currently available. This is a dependency property.
        /// </summary>
        public bool IsSaveOrLoadAvailable
        {
            get { return (bool)GetValue(IsSaveOrLoadAvailableProperty); }
            private set { SetValue(IsSaveOrLoadAvailableProperty, value); }
        }

        /// <summary>
        /// Get or set the file extension to use for restore points. This is a dependency property.
        /// </summary>
        public string FileExtension
        {
            get { return (string)GetValue(FileExtensionProperty); }
            set { SetValue(FileExtensionProperty, value); }
        }

        /// <summary>
        /// Get or set the style to use for the new button. This is a dependency property.
        /// </summary>
        public Style NewButtonStyle
        {
            get { return (Style)GetValue(NewButtonStyleProperty); }
            set { SetValue(NewButtonStyleProperty, value); }
        }

        /// <summary>
        /// Get or set the style to use for the delete button. This is a dependency property.
        /// </summary>
        public Style DeleteButtonStyle
        {
            get { return (Style)GetValue(DeleteButtonStyleProperty); }
            set { SetValue(DeleteButtonStyleProperty, value); }
        }

        /// <summary>
        /// Get or set the style to use for the save button. This is a dependency property.
        /// </summary>
        public Style SaveButtonStyle
        {
            get { return (Style)GetValue(SaveButtonStyleProperty); }
            set { SetValue(SaveButtonStyleProperty, value); }
        }

        /// <summary>
        /// Get or set the style to use for the load button. This is a dependency property.
        /// </summary>
        public Style LoadButtonStyle
        {
            get { return (Style)GetValue(LoadButtonStyleProperty); }
            set { SetValue(LoadButtonStyleProperty, value); }
        }

        /// <summary>
        /// Get or set the style to use for the status label. This is a dependency property.
        /// </summary>
        public Style StatusLabelStyle
        {
            get { return (Style)GetValue(StatusLabelStyleProperty); }
            set { SetValue(StatusLabelStyleProperty, value); }
        }

        /// <summary>
        /// Get or set the style to use for the available restore point list box. This is a dependency property.
        /// </summary>
        public Style AvailableRestorePointsListBoxStyle
        {
            get { return (Style)GetValue(AvailableRestorePointsListBoxStyleProperty); }
            set { SetValue(AvailableRestorePointsListBoxStyleProperty, value); }
        }

        #endregion

        #region DependencyProperties

        /// <summary>
        /// Identifies the NetAFFileManager.SelectedDirectoryPath property.
        /// </summary>
        public static readonly DependencyProperty SelectedDirectoryPathProperty = DependencyProperty.Register("SelectedDirectoryPath", typeof(string), typeof(NetAFFileManager), new PropertyMetadata(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "NetAF"), new PropertyChangedCallback(OnSelectedDirectoryPathPropertyChanged)));

        /// <summary>
        /// Identifies the NetAFFileManager.GameDirectoryPath property.
        /// </summary>
        public static readonly DependencyProperty GameDirectoryPathProperty = DependencyProperty.Register("GameDirectoryPath", typeof(string), typeof(NetAFFileManager), new PropertyMetadata(new PropertyChangedCallback(OnGameDirectoryPathPropertyChanged)));

        /// <summary>
        /// Identifies the NetAFFileManager.Status property.
        /// </summary>
        public static readonly DependencyProperty StatusProperty = DependencyProperty.Register("Status", typeof(string), typeof(NetAFFileManager));

        /// <summary>
        /// Identifies the NetAFFileManager.AvailableRestorePoints property.
        /// </summary>
        public static readonly DependencyProperty AvailableRestorePointsProperty = DependencyProperty.Register("AvailableRestorePoints", typeof(ObservableCollection<RestorePointPath?>), typeof(NetAFFileManager));

        /// <summary>
        /// Identifies the NetAFFileManager.IsSaveOrLoadAvailable property.
        /// </summary>
        public static readonly DependencyProperty IsSaveOrLoadAvailableProperty = DependencyProperty.Register("IsSaveOrLoadAvailable", typeof(bool), typeof(NetAFFileManager), new PropertyMetadata(false));

        /// <summary>
        /// Identifies the NetAFFileManager.FileExtension property.
        /// </summary>
        public static readonly DependencyProperty FileExtensionProperty = DependencyProperty.Register("FileExtension", typeof(string), typeof(NetAFFileManager), new PropertyMetadata("netaf", OnFileExtensionPropertyChanged));

        /// <summary>
        /// Identifies the NetAFFileManager.NewButtonStyle property.
        /// </summary>
        public static readonly DependencyProperty NewButtonStyleProperty = DependencyProperty.Register("NewButtonStyle", typeof(Style), typeof(NetAFFileManager));

        /// <summary>
        /// Identifies the NetAFFileManager.DeleteButtonStyle property.
        /// </summary>
        public static readonly DependencyProperty DeleteButtonStyleProperty = DependencyProperty.Register("DeleteButtonStyle", typeof(Style), typeof(NetAFFileManager));

        /// <summary>
        /// Identifies the NetAFFileManager.SaveButtonStyle property.
        /// </summary>
        public static readonly DependencyProperty SaveButtonStyleProperty = DependencyProperty.Register("SaveButtonStyle", typeof(Style), typeof(NetAFFileManager));

        /// <summary>
        /// Identifies the NetAFFileManager.LoadButtonStyle property.
        /// </summary>
        public static readonly DependencyProperty LoadButtonStyleProperty = DependencyProperty.Register("LoadButtonStyle", typeof(Style), typeof(NetAFFileManager));

        /// <summary>
        /// Identifies the NetAFFileManager.AvailableRestorePointListBoxStyle property.
        /// </summary>
        public static readonly DependencyProperty StatusLabelStyleProperty = DependencyProperty.Register("StatusLabelStyle", typeof(Style), typeof(NetAFFileManager));

        /// <summary>
        /// Identifies the NetAFFileManager.AvailableRestorePointsListBoxStyle property.
        /// </summary>
        public static readonly DependencyProperty AvailableRestorePointsListBoxStyleProperty = DependencyProperty.Register("AvailableRestorePointsListBoxStyle", typeof(Style), typeof(NetAFFileManager));

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the NetAFFileManager class.
        /// </summary>
        public NetAFFileManager()
        {
            InitializeComponent();

            EventBus.Subscribe<GameStarted>(x =>
            {
                game = x.Game;
                GameDirectoryPath = Path.Combine(SelectedDirectoryPath, game.Info.Name);
                Update(game);
            });
            EventBus.Subscribe<GameFinished>(_ =>
            {
                game = null;
                GameDirectoryPath = string.Empty;
                IsSaveOrLoadAvailable = false;
            });
            EventBus.Subscribe<GameUpdated>(x => Update(x.Game));
        }

        #endregion

        #region Methods

        private bool CheckDirectory(string directoryPath)
        {
            try
            {
                if (!Directory.Exists(directoryPath))
                    Directory.CreateDirectory(directoryPath);

                return true;
            }
            catch (Exception e)
            {
                Status = $"Could not create directory: {e.Message}";
                return false;
            }
        }

        private void PopulateRestorePoints(string directoryPath, string fileExtension)
        {
            try
            {
                var files = Directory.GetFiles(directoryPath, $"*.{fileExtension}");
                var sortedFiles = files.OrderByDescending(x => new FileInfo(x).LastWriteTime);
                List<RestorePointPath> restorePoints = [];

                foreach (var path in sortedFiles)
                {
                    if (!JsonSave.FromFile(path, out var restorePoint, out var message))
                    {
                        Status = $"Could not load restore point: {Path.GetFileName(path)}: {message}";
                        continue;
                    }
                    else
                    {
                        Status = $"Loaded {restorePoint.Name}.";
                    }

                    restorePoints.Add(new RestorePointPath(restorePoint, path));
                }

                AvailableRestorePoints = new ObservableCollection<RestorePointPath?>([.. restorePoints]);
                Status = "Populated restore points.";
            }
            catch (Exception e)
            {
                Status = $"Could not get restore points: {e.Message}";
            }
        }

        #endregion

        #region StaticMethods

        private static string GetFileName(DateTime dateTime)
        {
            return $"{dateTime.Year:D4}_{dateTime.Month:D2}_{dateTime.Day:D2}_{dateTime.Hour:D2}_{dateTime.Minute:D2}_{dateTime.Second:D2}_{dateTime.Millisecond:D3}";
        }

        #endregion

        #region PropertyChangedCallbacks

        private static void OnSelectedDirectoryPathPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var control = sender as NetAFFileManager;

            if (control == null)
                return;

            var newPath = e.NewValue?.ToString() ?? string.Empty;

            control.GameDirectoryPath = Path.Combine(newPath, control.game?.Info.Name ?? string.Empty);
        }

        private static void OnGameDirectoryPathPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var control = sender as NetAFFileManager;

            if (control == null)
                return;

            control.AvailableRestorePoints = [];

            var newPath = e.NewValue?.ToString() ?? string.Empty;

            if (!control.CheckDirectory(newPath))
                return;

            control.PopulateRestorePoints(newPath, control.FileExtension);
        }

        private static void OnFileExtensionPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var control = sender as NetAFFileManager;

            if (control == null)
                return;

            control.PopulateRestorePoints(control.GameDirectoryPath, e.NewValue?.ToString() ?? string.Empty);
        }

        #endregion

        #region CommandCallbacks

        private void SaveCommandBinding_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            if (game == null)
                return;

            var restorePoint = e.Parameter as RestorePointPath;

            var index = AvailableRestorePoints?.ToList()?.IndexOf(restorePoint) ?? AvailableRestorePoints?.IndexOf(null) ?? 0;
            var name = !string.IsNullOrEmpty(restorePoint?.RestorePoint.Name) ? restorePoint.RestorePoint.Name : game.Overworld?.CurrentRegion?.CurrentRoom?.Identifier.Name ?? "New restore point";
            var newRestorePoint = RestorePoint.Create(name, game);
            var extension = FileExtension;
            
            if (!extension.StartsWith('.'))
                extension = $".{extension}";

            var path = !string.IsNullOrEmpty(restorePoint?.Path) ? restorePoint?.Path : Path.Combine(GameDirectoryPath, $"{GetFileName(DateTime.Now)}{extension}");
            var newRestorePointPath = new RestorePointPath(newRestorePoint, path ?? string.Empty);

            if (JsonSave.ToFile(newRestorePointPath.Path, newRestorePointPath.RestorePoint, out var message) && AvailableRestorePoints != null)
            {
                AvailableRestorePoints[index] = newRestorePointPath;
                Status = $"Saved {newRestorePoint.Name}.";
            }
            else
            {
                Status = message;
            }
        }

        private void LoadCommandBinding_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            if (game == null)
                return;

            var restorePoint = e.Parameter as RestorePointPath;

            if (restorePoint == null)
                return;

            try
            {
                game.RestoreFrom(restorePoint.RestorePoint.Game);
                Status = $"Loaded: {restorePoint.RestorePoint.Name}.";

                // update to force frae redraw
                GameExecutor.Update();
            }
            catch (Exception ex)
            {
                Status = $"Could not load {restorePoint.RestorePoint.Name}: {ex.Message}";
            }
        }

        private void NewCommandBinding_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            var name = game?.Overworld?.CurrentRegion?.CurrentRoom?.Identifier.Name ?? "New restore point";
            var newRestorePoint = RestorePoint.Create(name, game);
            var extension = FileExtension;

            if (!extension.StartsWith('.'))
                extension = $".{extension}";

            var path = Path.Combine(GameDirectoryPath, $"{GetFileName(DateTime.Now)}{extension}");
            var newRestorePointPath = new RestorePointPath(newRestorePoint, path ?? string.Empty);

            if (JsonSave.ToFile(newRestorePointPath.Path, newRestorePointPath.RestorePoint, out var message) && AvailableRestorePoints != null)
            {
                AvailableRestorePoints.Insert(0, newRestorePointPath);
                Status = $"Created {newRestorePoint.Name}.";
            }
            else
            {
                Status = message;
            }
        }

        private void DeleteCommandBinding_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            if (game == null)
                return;

            var restorePoint = e.Parameter as RestorePointPath;

            if (restorePoint == null)
                return;

            try
            {
                File.Delete(restorePoint.Path);
            }
            catch (Exception ex)
            {
                Status = $"Couldn't delete {restorePoint.RestorePoint.Name}: {ex.Message}";
            }

            Status = $"Deleted {restorePoint.RestorePoint.Name}.";

            AvailableRestorePoints?.Remove(restorePoint);
        }

        #endregion

        #region Implementation of IUpdatable

        /// <summary>
        /// Update the component.
        /// </summary>
        /// <param name="game">The game to update based on.</param>
        public void Update(Game game)
        {
            IsSaveOrLoadAvailable = game?.Mode is SceneMode;
        }

        #endregion
    }
}

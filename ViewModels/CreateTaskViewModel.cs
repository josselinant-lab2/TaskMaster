using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TaskMaster.Models;
using TaskMaster.Services;

using TaskModel = TaskMaster.Models.Task;

namespace TaskMaster.UI.ViewModels
{
    public partial class CreateTaskViewModel : ObservableObject
    {
        private readonly ITaskService _taskService;
        private readonly IReferenceDataService _referenceDataService;

        [ObservableProperty]
        private string titre;

        [ObservableProperty]
        private string description;

        [ObservableProperty]
        private DateTime echeance = DateTime.Today;

        public ObservableCollection<Categorie> Categories { get; } = new ObservableCollection<Categorie>();
        public ObservableCollection<Priorite> Priorites { get; } = new ObservableCollection<Priorite>();
        public ObservableCollection<Statut> Statuts { get; } = new ObservableCollection<Statut>();

        [ObservableProperty]
        private Categorie selectedCategorie;

        [ObservableProperty]
        private Priorite selectedPriorite;

        [ObservableProperty]
        private Statut selectedStatut;

        public CreateTaskViewModel(ITaskService taskService, IReferenceDataService referenceDataService)
        {
            _taskService = taskService;
            _referenceDataService = referenceDataService;
            LoadReferenceDataAsync();
        }

        private async void LoadReferenceDataAsync()
        {
            var currentUser = SessionService.CurrentUser;
            if (currentUser != null)
            {
                var categories = await _referenceDataService.GetCategoriesAsync(currentUser.Id_User);
                Categories.Clear();
                foreach (var cat in categories)
                    Categories.Add(cat);
            }

            var priorites = await _referenceDataService.GetPrioritesAsync();
            Priorites.Clear();
            foreach (var p in priorites)
                Priorites.Add(p);

            var statuts = await _referenceDataService.GetStatutsAsync();
            Statuts.Clear();
            foreach (var s in statuts)
                Statuts.Add(s);
        }

        [RelayCommand]
        private async System.Threading.Tasks.Task ValidateAsync()
        {
            if (string.IsNullOrWhiteSpace(Titre))
            {
                return;
            }
            if (SelectedCategorie == null || SelectedPriorite == null || SelectedStatut == null)
            {
                return;
            }

            var currentUser = SessionService.CurrentUser;
            if (currentUser == null)
            {
                return;
            }

            TaskModel newTask = new TaskModel
            {
                Titre = this.Titre,
                Description = this.Description,
                Echeance = this.Echeance,
                DateCreation = DateTime.Now,
                Id_Categorie = SelectedCategorie.Id_Categorie,
                Id_Priorite = SelectedPriorite.Id_Priorite,
                Id_Statut = SelectedStatut.Id_Statut
            };

            if (newTask.RelationUserTasks == null)
                newTask.RelationUserTasks = new System.Collections.Generic.List<RelationUserTasks>();

            newTask.RelationUserTasks.Add(new RelationUserTasks
            {
                Id_User = currentUser.Id_User,
                Libelle = "Créateur"
            });

            await _taskService.AddTaskAsync(newTask);

            await Shell.Current.GoToAsync("///TaskListPage");
        }
    }
}

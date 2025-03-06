﻿using CommunityToolkit.Mvvm.ComponentModel;

namespace Ping.Models.Task
{
    public partial class Task : ObservableObject, ITask
    {
        public Guid Id { get; set; }
        [ObservableProperty]
        private string _name;
        [ObservableProperty]
        private string _description = string.Empty;
        [ObservableProperty]
        private Priority _priority = Priority.None;
        [ObservableProperty]
        private DateTime _deadline;
        [ObservableProperty]
        private bool _isCompleted = false;

        public Task(string name, DateTime deadline)
        {
            Id = Guid.NewGuid();
            Name = name;
            Deadline = deadline;
        }

        public void MarkCompleted()
        {
            IsCompleted = true;
            Save();
        }

        public void Save() =>
            StorageManager.SaveAsJson(this, Id.ToString());

        public void Delete() =>
            StorageManager.Delete(Id.ToString());
    }
}

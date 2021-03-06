﻿using ArmyBase.DTO;
using ArmyBase.Service;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ArmyBase.ViewModels.Permission
{
    public class PermissionGridViewModel : Screen
    {
        public List<PermissionDTO> Permissions { get; set; } = new List<PermissionDTO>();
        public PermissionGridViewModel()
        {
            Reload();
        }

        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
        }

        public void LoadModifyPermissionPage(PermissionDTO permission)
        {
            IWindowManager manager = new WindowManager();
            AddPermissionViewModel modify = new AddPermissionViewModel(permission);
            manager.ShowDialog(modify, null, null);
            Reload();
        }

        public void Delete(PermissionDTO permission)
        {
            IWindowManager manager = new WindowManager();
            DeleteConfirmationViewModel modify = new DeleteConfirmationViewModel();
            bool? showDialogResult = manager.ShowDialog(modify, null, null);
            if (showDialogResult != null && showDialogResult == true)
            {
                PermissionService.Delete(permission);
            }
            Reload();
        }

        public void Reload()
        {
            Permissions = PermissionService.GetAll();
            NotifyOfPropertyChange(() => Permissions);
        }
    }
}

// <copyright file="INavigationService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Presentation.Services
{
    using System;
    using Presentation.Core;

    public interface INavigationService
    {
        ViewModel CurrentView { get; }

        void NavigateTo<T>()
            where T : ViewModel;

        void InitParam<TView>(Action<TView> initFunc)
            where TView : ViewModel;
    }
}

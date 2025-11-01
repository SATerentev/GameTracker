﻿using System.ComponentModel.DataAnnotations;

namespace GameTracker.ViewModel.Account
{
    public class EmailViewModel
    {
        [Required]
        [EmailAddress(ErrorMessage = "Введите корректный адрес электронной почты.")]
        public string Email { get; set; }
    }
}

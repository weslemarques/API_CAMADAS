﻿using System.Diagnostics.CodeAnalysis;
using CRUD_ESTUDANTES.Entities;

namespace CRUD_ESTUDANTES.DTO.Response;

public class StudentResponse
{
    public StudentResponse(Student student)
    {
        Id = student.Id;
        
        Name = student.Name;
        Course = student.Course;
        Email = student.Email;
        Password = student.Password;
    }

    public Guid Id { get; set; }
    [NotNull]
    public string Name { get; set; }
    [NotNull]
    public string Course { get; set; } 
    public string Email { get; set; } 
    public string Password { get; set; } 
    
    
    
    
}
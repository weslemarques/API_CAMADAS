﻿using CRUD_ESTUDANTES.DTO.Request;
using CRUD_ESTUDANTES.DTO.Response;
using CRUD_ESTUDANTES.Entities;
using CRUD_ESTUDANTES.Repositories.Contract;
using CRUD_ESTUDANTES.Services.Contract;

namespace CRUD_ESTUDANTES.Services;

public class StudentService : IStudentService
{
    private IStudentRepository StudentRepository { get; set; }

    public StudentService(IStudentRepository studentRepository)
    {
        StudentRepository = studentRepository;
    }

    public List<StudentResponse> GetAll()
    {
        try
        {
            return StudentRepository
                .GetAll()
                .Result
                .ConvertAll(std => new StudentResponse(std));
        }
        catch (Exception e)
        {
            throw new Exception("get all fail");
        }
    }

    public StudentResponse GetById(Guid id)
    {

        try
        { 
            Student? entity = StudentRepository.GetById(id).Result;
            return new StudentResponse(entity);
        }
        catch (Exception e)
        {
            throw new Exception("Entity Not Found");
        }
        
    }

    public StudentResponse Save(StudentInsert? dto)
    {
        
        try
        {
            Student? student = new Student(dto.Name, dto.Course);
           student = StudentRepository.Save(student).Result;
           return new StudentResponse(student);
        }
        catch (Exception e)
        {
            throw new Exception("entity not found");
        }
    }

    public StudentResponse Update(StudentUpdate? dto, Guid id)
    {
        try
        {
            Student? entity = StudentRepository.GetById(id).Result;
            entity.Name = dto.Name;
            entity.Course = dto.Course;
            entity  = StudentRepository.Update(entity).Result;
            return new StudentResponse(entity);
        }
        catch (Exception e)
        {
            throw new Exception("Não atualizado");
        }
        
    }

    public void Delete(Guid id)
    {
        StudentRepository.Delete(id);
    }
}
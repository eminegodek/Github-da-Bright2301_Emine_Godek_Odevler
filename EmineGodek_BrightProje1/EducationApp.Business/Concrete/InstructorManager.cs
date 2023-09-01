using EducationApp.Business.Abstract;
using EducationApp.Data.Abstract;
using EducationApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.Business.Concrete
{
	public class InstructorManager : IInstructorService
	{
		private readonly IInstructorRepository _instructorRepository;

		public InstructorManager(IInstructorRepository instructorRepository)
		{
			_instructorRepository = instructorRepository;
		}

		public async Task CreateAsync(Instructor instructor)
		{
			await _instructorRepository.CreateAsync(instructor);
		}

		public async Task CreateWithUrl(Instructor instructor)
		{
			await _instructorRepository.CreateWithUrl(instructor);
		}

		public void Delete(Instructor instructor)
		{
			_instructorRepository.Delete(instructor);
		}

		public async Task<List<Instructor>> GetAllActiveInstructorsAsync(string categoryUrl = null, string instructorUrl = null)
		{
			var result = await _instructorRepository.GetAllActiveInstructorsAsync(categoryUrl, instructorUrl);
			return result;
		}

		public async Task<List<Instructor>> GetAllAsync()
		{
			var result = await _instructorRepository.GetAllAsync();
			return result;
		}

		public async Task<List<Instructor>> GetAllInstructorsAsync(bool isDeleted, bool? isActive = null)
		{
			var result = await _instructorRepository.GetAllInstructorsAsync(isDeleted, isActive);
			return result;
		}

		public async Task<Instructor> GetByIdAsync(int id)
		{
			var result = await _instructorRepository.GetByIdAsync(id);
			return result;
		}

		public async Task<Instructor> GetInstructorsByUrlAsync(string instructorUrl)
		{
			var result = await _instructorRepository.GetInstructorsByUrlAsync(instructorUrl);
			return result;
		}

		public async Task<List<Instructor>> GetInstructorsWithFullDataAsync(bool? isActive = null)
		{
			var result = await _instructorRepository.GetInstructorsWithFullDataAsync(isActive);
			return result;
		}

		public void Update(Instructor instructor)
		{
			_instructorRepository.Update(instructor);
		}
	}
}

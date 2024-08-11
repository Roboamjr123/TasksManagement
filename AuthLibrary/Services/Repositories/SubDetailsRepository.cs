using AuthLibrary.Dtos;
using AuthLibrary.Services.Interface;
using AutoMapper;
using DataLibrary.Database;
using DataLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthLibrary.Services.Repositories
{
    public class SubDetailsRepository : ISubDetails
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public SubDetailsRepository(DataContext context,IMapper mapper) 
        { 
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> AddSubDetails(SubDetailsDtos subDetails)
        {
            var subDetail = _mapper.Map<SubDetails>(subDetails);
            _context.SubDetail.Add(subDetail);
            await _context.SaveChangesAsync();
            return "SubDetail add successfully";
        }

        public async Task<IEnumerable<SubDetails>> GetAllSubDetails()
        {
            return await _context.SubDetail.ToListAsync();
        }

        public async Task<IEnumerable<SubTasksDtos>> GetSubDetailsByInfo()
        {
            var subDetails = await _context.SubDetail.ToListAsync(); // Adjust the query based on your actual filtering criteri
            return _mapper.Map<IEnumerable<SubTasksDtos>>(subDetails);
        }

        public async Task<bool> UpdateSubDetails(int id, SubDetailsDtos subDetailsDto)
        {
            // Retrieve the existing entity
            var existingSubDetail = await _context.SubDetail.FindAsync(id);
            if (existingSubDetail == null) return false; // Return false if the entity is not found

            // Map the updated values from the DTO to the existing entity
            _mapper.Map(subDetailsDto, existingSubDetail);

            // Update the entity in the context
            _context.SubDetail.Update(existingSubDetail);
            await _context.SaveChangesAsync();

            return true; // Return true if the update was successful
        }


        public async Task<bool> DeleteSubDetails(SubDetailsDtos subDetailsDto)
        {
            // Find the existing entity by ID from the DTO
            var existingSubDetail = await _context.SubDetail.FindAsync(subDetailsDto.SubD_Id);
            if (existingSubDetail == null) return false; // Return false if the entity is not found

            // Remove the entity
            _context.SubDetail.Remove(existingSubDetail);
            await _context.SaveChangesAsync();

            return true; // Return true if the delete was successful
        }

       
    }
}

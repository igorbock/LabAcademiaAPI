global using System.ComponentModel.DataAnnotations.Schema;
global using System.ComponentModel.DataAnnotations;
global using System.Text.Json.Serialization;
global using System.Text.Json;
global using System.Security.Claims;

global using LabAcademiaAPI.Models;
global using LabAcademiaAPI.Models.DTOs;
global using LabAcademiaAPI.Context;
global using LabAcademiaAPI.Interfaces;
global using LabAcademiaAPI.Interfaces.Services;
global using LabAcademiaAPI.Services;
global using LabAcademiaAPI.Extensions;
global using LabAcademiaAPI.Repositories;
global using LabAcademiaAPI.Requirements;

global using Microsoft.EntityFrameworkCore;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.IdentityModel.Tokens;
global using Microsoft.OpenApi.Models;
global using Microsoft.AspNetCore.Identity;
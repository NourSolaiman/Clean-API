﻿using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace Application
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddApplication(this IServiceCollection services)
		{
			var assembly = typeof(DependencyInjection).Assembly;
			services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(assembly));
			services.AddValidatorsFromAssembly(assembly);
			return services;
		}

	}
}

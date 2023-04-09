using AutoMapper.Execution;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace OfficingEdge.Extentions
{
	public class TimeOnlyEfConverter : ValueConverter<TimeOnly,TimeSpan>
	{
		public TimeOnlyEfConverter() : base(
			t => t.ToTimeSpan(),
			ts => TimeOnly.FromTimeSpan(ts))
		{ }

	}
}

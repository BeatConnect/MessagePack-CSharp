﻿// <auto-generated />

#pragma warning disable 618, 612, 414, 168, CS1591, SA1129, SA1309, SA1312, SA1403, SA1649

namespace MessagePack {

using MsgPack = global::MessagePack;

/// <summary>A MessagePack resolver that uses generated formatters for types in this assembly.</summary>
partial class GeneratedMessagePackResolver : MsgPack::IFormatterResolver
{
	/// <summary>An instance of this resolver that only returns formatters specifically generated for types in this assembly.</summary>
	public static readonly MsgPack::IFormatterResolver Instance = new GeneratedMessagePackResolver();

	/// <summary>An instance of this resolver that returns standard AOT-compatible formatters as well as formatters specifically generated for types in this assembly.</summary>
	public static readonly MsgPack::IFormatterResolver InstanceWithStandardAotResolver = MsgPack::Resolvers.CompositeResolver.Create(Instance, MsgPack::Resolvers.StandardAotResolver.Instance);

	private GeneratedMessagePackResolver()
	{
	}

	public MsgPack::Formatters.IMessagePackFormatter<T> GetFormatter<T>()
	{
		return FormatterCache<T>.Formatter;
	}

	private static class FormatterCache<T>
	{
		internal static readonly MsgPack::Formatters.IMessagePackFormatter<T> Formatter;

		static FormatterCache()
		{
			var f = GeneratedMessagePackResolverGetFormatterHelper.GetFormatter(typeof(T));
			if (f != null)
			{
				Formatter = (MsgPack::Formatters.IMessagePackFormatter<T>)f;
			}
		}
	}

	private static class GeneratedMessagePackResolverGetFormatterHelper
	{
		private static readonly global::System.Collections.Generic.Dictionary<global::System.Type, int> lookup;

		static GeneratedMessagePackResolverGetFormatterHelper()
		{
			lookup = new global::System.Collections.Generic.Dictionary<global::System.Type, int>(4)
			{
					{ typeof(global::System.Collections.Generic.IEnumerable<global::System.Guid>), 0 },
					{ typeof(global::TempProject.Wrapper<global::System.Collections.Generic.IEnumerable<global::System.Guid>>), 1 },
					{ typeof(global::TempProject.Wrapper<int[]>), 2 },
					{ typeof(global::TempProject.Wrapper<string>), 3 },
				};
		}

		internal static object GetFormatter(global::System.Type t)
		{
			int key;
			if (!lookup.TryGetValue(t, out key))
			{
				return null;
			}

			switch (key)
			{
					case 0: return new MsgPack::Formatters.InterfaceEnumerableFormatter<global::System.Guid>();
					case 1: return new WrapperFormatter<global::System.Collections.Generic.IEnumerable<global::System.Guid>>();
					case 2: return new WrapperFormatter<int[]>();
					case 3: return new WrapperFormatter<string>();
					default: return null;
			}
		}
	}
}

}

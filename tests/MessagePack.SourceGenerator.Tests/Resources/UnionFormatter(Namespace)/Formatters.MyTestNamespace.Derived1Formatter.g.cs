﻿// <auto-generated />

#pragma warning disable 618, 612, 414, 168, CS1591, SA1129, SA1309, SA1312, SA1403, SA1649

#pragma warning disable CS8669 // We may leak nullable annotations into generated code.

namespace MessagePack {

using MsgPack = global::MessagePack;

partial class GeneratedMessagePackResolver
{
	private sealed class Derived1Formatter : MsgPack::Formatters.IMessagePackFormatter<global::MyTestNamespace.Derived1>
	{

		public void Serialize(ref MsgPack::MessagePackWriter writer, global::MyTestNamespace.Derived1 value, MsgPack::MessagePackSerializerOptions options)
		{
			if (value == null)
			{
				writer.WriteNil();
				return;
			}

			writer.WriteArrayHeader(0);
		}

		public global::MyTestNamespace.Derived1 Deserialize(ref MsgPack::MessagePackReader reader, MsgPack::MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				return null;
			}

			reader.Skip();
			return new global::MyTestNamespace.Derived1();
		}
	}
}

}

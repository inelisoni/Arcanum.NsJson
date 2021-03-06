﻿// Copyright (c) Kornei Dontsov. All Rights Reserved. Licensed under the MIT. See LICENSE in the project root for license information.

namespace Arcanum.NsJson.Contracts {
	public static class MicroContractResolverBuilderFunctions {
		static class Singleton<T> where T: class, new() {
			public static T instance { get; } = new T();
		}

		public static IMicroContractResolverBuilder AddCreator<TData, T> (this IMicroContractResolverBuilder builder)
		where T: class, IJsonContractCreator, new() =>
			builder.AddCreator(typeof(TData), Singleton<T>.instance);

		public static IMicroContractResolverBuilder AddFactory<T> (this IMicroContractResolverBuilder builder)
		where T: class, IJsonContractFactory, new() =>
			builder.AddFactory(Singleton<T>.instance);

		public static IMicroContractResolverBuilder AddPatch<T> (this IMicroContractResolverBuilder builder)
		where T: class, IJsonContractPatch, new() =>
			builder.AddPatch(Singleton<T>.instance);

		public static IMicroContractResolverBuilder AddMiddlewareFactory<T> (this IMicroContractResolverBuilder builder)
		where T: class, IJsonMiddlewareFactory, new() =>
			builder.AddMiddlewareFactory(Singleton<T>.instance);
	}
}

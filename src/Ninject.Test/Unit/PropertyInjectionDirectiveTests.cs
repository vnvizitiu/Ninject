﻿using System;
using System.Reflection;
using Ninject.Injection;
using Ninject.Planning.Directives;
using Xunit;

namespace Ninject.Tests.Unit.PropertyInjectionDirectiveTests
{
    using FluentAssertions;

    public class PropertyInjectionDirectiveContext
    {
        protected PropertyInjectionDirective directive;
    }

    public class WhenDirectiveIsCreated : PropertyInjectionDirectiveContext
    {
        [Fact]
        public void CreatesTargetForProperty()
        {
#if !WINRT
            var method = typeof(Dummy).GetProperty("Foo");
#else
            var method = typeof(Dummy).GetRuntimeProperty("Foo");
#endif
            PropertyInjector injector = delegate { };

            directive = new PropertyInjectionDirective(method, injector);

            directive.Target.Name.Should().Be("Foo");
            directive.Target.Type.Should().Be(typeof(int));
        }
    }

    public class Dummy
    {
        public int Foo { get; set; }
    }
}
﻿// <copyright file="SeedingFeature.cs" company="ConfigR contributors">
//  Copyright (c) ConfigR contributors. (configr.net@gmail.com)
// </copyright>

namespace ConfigR.Tests.Acceptance.Roslyn.CSharp
{
    using System.Collections.Generic;
    using ConfigR.Tests.Acceptance.Roslyn.CSharp.Support;
    using FluentAssertions;
    using Xbehave;

    public static class SeedingFeature
    {
        [Scenario]
        public static void SeedingAScriptWithAnObject(string result)
        {
            dynamic config = null;

            "Given a local config file which sets Foo using the value of Bar"
                .f(c => ConfigFile.Create(@"Config.Foo = Config.Bar;").Using(c));

            "And I load the config seeded with Bar set to 'baz'"
                .f(async () => config = await new Config().UseRoslynCSharpLoader().LoadDynamic(new { Bar = "baz" }));

            "And I get Foo"
                .f(() => result = config.Foo<string>());

            "Then Foo is 'baz'"
                .f(() => result.Should().Be("baz"));
        }

        [Scenario]
        public static void SeedingAScriptWithADictionary(string result)
        {
            dynamic config = null;

            "Given a local config file which sets Foo using the value of Bar"
                .f(c => ConfigFile.Create(@"Config.Foo = Config.Bar;").Using(c));

            "And I load the config seeded with Bar set to 'baz'"
                .f(async () => config = await new Config().UseRoslynCSharpLoader().LoadDynamic(new Dictionary<string, object> { { "Bar", "baz" } }));

            "And I get Foo"
                .f(() => result = config.Foo<string>());

            "Then Foo is 'baz'"
                .f(() => result.Should().Be("baz"));
        }

        [Scenario]
        public static void SeedingAScriptWithAnObjectAndReceivingADictionary(string result)
        {
            IDictionary<string, object> config = null;

            "Given a local config file which sets Foo using the value of Bar"
                .f(c => ConfigFile.Create(@"Config.Foo = Config.Bar;").Using(c));

            "And I load the config seeded with Bar set to 'baz'"
                .f(async () => config = await new Config().UseRoslynCSharpLoader().LoadDictionary(new { Bar = "baz" }));

            "And I get Foo"
                .f(() => result = config.Get<string>("Foo"));

            "Then Foo is 'baz'"
                .f(() => result.Should().Be("baz"));
        }

        [Scenario]
        public static void SeedingAScriptWithADictionaryAndReceivingADictionary(string result)
        {
            IDictionary<string, object> config = null;

            "Given a local config file which sets Foo using the value of Bar"
                .f(c => ConfigFile.Create(@"Config.Foo = Config.Bar;").Using(c));

            "And I load the config seeded with Bar set to 'baz'"
                .f(async () => config = await new Config().UseRoslynCSharpLoader().LoadDictionary(new Dictionary<string, object> { { "Bar", "baz" } }));

            "And I get Foo"
                .f(() => result = config.Get<string>("Foo"));

            "Then Foo is 'baz'"
                .f(() => result.Should().Be("baz"));
        }
    }
}

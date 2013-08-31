﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SassyStudio.Compiler.Parsing;

namespace SassyStudio.Editor.Intellisense
{
    class IntellisenseCache : IIntellisenseCache
    {
        delegate IIntellisenseContainer ContainerFactory(ComplexItem item);
        static readonly IDictionary<Type, ContainerFactory> ContainerFactoryMappings;
        static readonly IEnumerable<ICompletionValue> SystemFunctions; 
        static IntellisenseCache()
        {
            ContainerFactoryMappings = new Dictionary<Type, ContainerFactory>
            {
                { typeof(MixinDefinition), item => new MixinContainer(item as MixinDefinition) },
                { typeof(UserFunctionDefinition), item => new FunctionContainer(item as UserFunctionDefinition) }
            };

            SystemFunctions = Scss.ScssWellKnownFunctionNames.Names.Select(name => new SystemFunctionCompletionValue
            {
                CompletionText = name,
                DisplayText = name
            }).ToArray();
        }

        readonly ISassDocument Document;
        readonly IIntellisenseManager IntellisenseManager;
        public IntellisenseCache(ISassDocument document, IIntellisenseManager intellisenseManager)
        {
            Document = document;
            IntellisenseManager = intellisenseManager;
        }

        IIntellisenseContainer Container { get; set; }

        public void Update(ISassStylesheet stylesheet, ITextProvider text)
        {
            var container = new StylesheetContainer();
            foreach (var item in stylesheet.Children)
                container.Add(item, text);

            Container = container;
        }

        public IEnumerable<ICompletionValue> GetVariables(int position)
        {
            return Container.GetVariables(position);
        }

        public IEnumerable<ICompletionValue> GetFunctions(int position)
        {
            return SystemFunctions.Concat(Container.GetFunctions(position));
        }

        public IEnumerable<ICompletionValue> GetMixins(int position)
        {
            return Container.GetMixins(position);
        }
    }
}
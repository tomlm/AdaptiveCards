// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License
#pragma once

#include "AdaptiveRichTextBlockRenderer.g.h"

namespace winrt::AdaptiveCards::Rendering::Uwp::implementation
{
    struct AdaptiveRichTextBlockRenderer : AdaptiveRichTextBlockRendererT<AdaptiveRichTextBlockRenderer>
    {
        AdaptiveRichTextBlockRenderer() = default;

        winrt::UIElement Render(winrt::IAdaptiveCardElement const& cardElement,
                                                   winrt::AdaptiveRenderContext const& renderContext,
                                                   winrt::AdaptiveRenderArgs const& renderArgs);
    };
}
namespace winrt::AdaptiveCards::Rendering::Uwp::factory_implementation
{
    struct AdaptiveRichTextBlockRenderer
        : AdaptiveRichTextBlockRendererT<AdaptiveRichTextBlockRenderer, implementation::AdaptiveRichTextBlockRenderer>
    {
    };
}
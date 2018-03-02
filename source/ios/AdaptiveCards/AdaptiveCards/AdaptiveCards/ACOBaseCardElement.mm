//
//  ACOBaseCardElement
//  ACOBaseCardElement.mm
//
//  Copyright © 2018 Microsoft. All rights reserved.
//
#import <Foundation/Foundation.h>
#import "ACOBaseCardElement.h"
#import "BaseCardElement.h"

using namespace AdaptiveCards;

@implementation ACOBaseCardElement
{
    std::shared_ptr<BaseCardElement> _elem;
}

- (instancetype)initWithBaseCardElement:(std::shared_ptr<BaseCardElement> const &)element
{
    self = [super init];
    if(self && element) {
        _elem = element;
        _type = (ACRCardElementType)element->GetElementType();
    }
    return self;
}

- (instancetype)init
{
    self = [self initWithBaseCardElement:nil];
    return self;
}

- (std::shared_ptr<BaseCardElement>)element
{
    return _elem;
}

- (void)setElem:(std::shared_ptr<BaseCardElement> const &)elem
{
    _elem = elem;
}

@end
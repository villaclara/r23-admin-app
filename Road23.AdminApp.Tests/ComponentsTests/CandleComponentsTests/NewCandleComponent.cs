using Xunit;
using Bunit;
using AdminApp.WASM.Components.Misc;

namespace Road23.AdminApp.Tests;

public class NewCandleComponent : TestContext
{

    [Fact]
    public void AddCandleButtonRendersCorrectly()
    {
        // Act
        var cut = RenderComponent<ButtonWithSpinnerAction>();

        //Assert
        cut.MarkupMatches("""<button class="@ButtonCss" disabled="@IsButtonPressed"><span class="@SetButtonCssSpinner(IsButtonPressed)" aria-hidden="true"></span><span>@ButtonText</span></button>""");
    }

}

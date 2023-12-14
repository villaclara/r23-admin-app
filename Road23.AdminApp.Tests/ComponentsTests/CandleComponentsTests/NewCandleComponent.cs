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
        cut.MarkupMatches("""<button class="" disabled=""><span class="" aria-hidden="true"></span><span></span></button>""");

    }

}

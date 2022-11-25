$(document).ready(function () {
    $(".bankPayment").hide();
    $(".paymentDeposit").hide();
    $('input[type="radio"]').click(function () {
        var inputValue = $(this).attr("value");
        var targetBox = $("." + inputValue);
        $(".box").not(targetBox).hide();
        $(targetBox).show();
    });
    $('input[id="Deposit"]').click(function () {
        if ($(this).prop("checked") == true) {
            $(".paymentFull").hide();
            $(".paymentDeposit").show();
        }
        else {
            $(".paymentDeposit").hide();
            $(".paymentFull").show();
        }
    });
});
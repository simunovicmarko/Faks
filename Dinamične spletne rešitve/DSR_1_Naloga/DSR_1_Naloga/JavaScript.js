$(document).ready(() => {

    let ste1 = $("#MainContent_st1")[0].value;
    let ste2 = $("#MainContent_st2")[0].value;

    var op = $("#MainContent_oper")[0].value;

    let min = 0;
    let max = 100;

    $(() => {
        $("#slider").slider("option", "min", min);
        $("#slider").slider("option", "max", max);

        $("#slider2").slider("option", "min", min);
        $("#slider2").slider("option", "max", max);
    })


    /* try {*/
    if (ste1 && ste2 && ste1.length > 0 && ste2.length > 0) {
        ste1 = parseInt(ste1);
        ste2 = parseInt(ste2);
    }

    if ((Number.isNaN(ste1) || Number.isNaN(ste2)) && ste1 !== undefined && ste2 !== undefined) {
        alert("Nepravilen vnos")
    }
    else {


        document.getElementById("MainContent_s1").value = ste1;
        document.getElementById("MainContent_s2").value = ste2;

        let res;
        switch (op) {
            case "plus":
                res = ste1 + ste2;
                $("#pristej").attr("checked", true);
                document.getElementById("MainContent_ope").value = "plus";
                $("#res").val(res)
                break;
            case "minus":
                res = ste1 - ste2;
                $("#res").val(res)
                document.getElementById("MainContent_ope").value = "minus";
                $("#odstej").attr("checked", true);
                break;

            case "krat":
                res = ste1 * ste2;
                $("#mnozi").attr("checked", true);
                document.getElementById("MainContent_ope").value = "krat";
                $("#res").val(res)
                break;

            case "deljeno":
                console.log(String(ste2))
                if (ste2 !== 0 && String(ste2).length > 0) {
                    res = ste1 / ste2;
                    $("#res").val(res)
                }
                else
                    alert("Deljenje z nič");

                document.getElementById("MainContent_ope").value = "deljeno";
                $("#deli").attr("checked", true);
                break;
            default:
                if (op.length > 0) {
                    alert("Napačen vnos")
                }

        }
    }

    //} catch (e) {
    //    alert("Nepravilen vnos")
    //}

});
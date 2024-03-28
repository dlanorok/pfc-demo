app = (function(){
    var paisDropDown, provinciaDropDown, ciudadDropDown;
    function eliminarRegistro(url) {
        var $url_eliminar_persona = url;

        $.ajax({
            type: "POST",
            url: $url_eliminar_persona,
            success: function (result) {
                var msg = "No se pudo eliminar el registro! Intente nuevamente...";
                if (result) {
                    if (result.Success) {
                        showDeleteSuccess()
                        return;
                    } else {
                        msg = result.Message || result.message;
                    }
                }

                showDeleteError(msg);
            },
            error: function (error) {
                var msg = "No se pudo eliminar el registro! Intente nuevamente...";
                if (error && error.message) {
                    msg = error.Message || error.message || error.responseText;
                }

                showDeleteError(msg);
            }
        });
    }


    function showDeleteSuccess() {
        $(".alert-delete-success").show();

        setTimeout(function () {
            $(".alert-delete-success").hide();
            location.reload();
        }, 1000);
    }


    function showDeleteError(msg) {
        $(".alert-delete-error").html(msg);
        $(".alert-delete-error").show();

        setTimeout(function () {
            $(".alert-delete-error").hide();
        }, 5000);
    }


    function createOption(text){
        var option = document.createElement("option");
        option.text = text;
        return option;
    }
    
    function refreshProvincias(paisId){
        ciudadDropDown.innerHTML = "";
        provinciaDropDown.innerHTML = "";
        fetch(`/catalogo/GetProvinciasByPaisId/${paisId}`)
            .then(function (response) {
                if (response.ok) {
                    response.json().then(result =>{
                        var provincias = result.Result;
                        if (provincias && provincias.length > 0){
                            for (var i = 0; i < provincias.length; i++) {
                                var provincia = provincias[i];
                                provinciaDropDown.appendChild(createOption(provincia.Nombre));
                            }
                            refreshCiudades(provincias[0].Id);
                        }
                    });
                }
            });

    }
    
    function refreshCiudades(provinciaId){
        ciudadDropDown.innerHTML = "";
        fetch(`/catalogo/GetCiudadesByProvinciaId/${provinciaId}`)
            .then(function (response) {
                if (response.ok){
                    response.json().then(result =>{
                        if (result.Success) {
                            var ciudades = result.Result;
                            if (ciudades && ciudades.length > 0){
                                for (var i = 0; i < ciudades.length; i++) {
                                    var ciudad = ciudades[i];
                                    ciudadDropDown.appendChild(createOption(ciudad.Nombre))
                                }
                            }
                        }
                    });
                }
            });
    }


    function show_modal_cuenta($url) {
        $('#divModal').empty();

        $.ajax({
            url: $url,
            type: 'GET',
            beforeSend: function () {
            },
            complete: function () {
            }
        }).done(function (respuesta) {
            if (respuesta != '') {
                $('#divModal').html(respuesta);
                $('#divModal').modal('show', { backdrop: 'static' });
            } else {
                $('#divModal').modal('hide');
            }
        });
    }

    function eliminar_cuenta(url$) {

        $.ajax({
            type: "POST",
            url: url$,
            success: function (result) {
                var msg = "No se pudo eliminar el registro! Intente nuevamente...";
                if (result) {
                    if (result.Success) {
                        showDeleteSuccess()
                        return;
                    } else {
                        msg = result.Message || result.message;
                    }
                }

                showDeleteError(msg);
            },
            error: function (error) {
                var msg = "No se pudo eliminar el registro! Intente nuevamente...";
                if (error && error.message) {
                    msg = error.Message || error.message || error.responseText;
                }

                showDeleteError(msg);
            }
        });
    }


    function showDeleteSuccess() {
        $(".alert-delete-success").show();

        setTimeout(function () {
            $(".alert-delete-success").hide();
            location.reload();
        }, 1000);
    }


    function showDeleteError(msg) {
        $(".alert-delete-error").html(msg);
        $(".alert-delete-error").show();

        setTimeout(function () {
            $(".alert-delete-error").hide();
        }, 5000);
    }


    function guardarCuentaBancaria(e) {
        e.preventDefault();
        var cuentaBancariaForm = e.target;
        
        $.validator.unobtrusive.parse($(cuentaBancariaForm));
        if (!$(cuentaBancariaForm).valid())
            return false;

        var action = $(cuentaBancariaForm).attr("data-action");
        var form_data = $(cuentaBancariaForm).serializeJson();
        console.log(action, form_data);
        $.ajax({
            type: "POST",
            url: action,
            data: form_data,
            success: function (result) {
                var msg = "No se pudo guardar el registro! Intente nuevamente...";
                if (result) {
                    if (result.Success) {
                        $(".alert-save-success").show();
                        $("#divModal").modal("hide");
                        location.reload();
                        return;

                    } else {
                        msg = result.Message || result.message;
                    }
                }

                showEditError(msg);
            },
            error: function (error) {
                var msg = "No se pudo guardar el registro! Intente nuevamente...";
                if (error && error.message) {
                    msg = error.Message || error.message || error.responseText;
                }

                showEditError(msg);
            }
        });
    }

    function showEditError(msg) {
        $(".alert-save-error").html(msg);
        $(".alert-save-error").show();

        setTimeout(function () {
            $(".alert-save-error").hide();
        }, 5000);
    }
    
    return {
         
        cliente : {
            configure_editor: function () {
                paisDropDown = document.getElementById("Pais");
                provinciaDropDown = document.getElementById("Provincia");
                ciudadDropDown = document.getElementById("Ciudad");

                paisDropDown.addEventListener("change", function (e) {
                    var paisId = e.target.value;
                    refreshProvincias(paisId);
                });

                provinciaDropDown.addEventListener("change", function (e) {
                    var provinciaId = e.target.value;
                    refreshCiudades(provinciaId);
                }); 
            },


            configure_delete: function () {
                var buttons = document.getElementsByClassName("eliminar-persona");
                for (var i = 0; i < buttons.length; i++) {
                    var btn = buttons[i];
                    var url = btn.attributes.getNamedItem("data-action-url");

                    btn.addEventListener("click", function () {
                        var eliminar = confirm("Esta seguro que desea eliminar este registro?");
                        if (eliminar) {
                            eliminarRegistro(url.value);
                        }
                    });
                }
            },
        },
        
        cuenta_bancaria: {
            initialize: function ($url_crear_cuenta, $url_editar_cuenta, $url_eliminar_cuenta) {

                $(".add-cuenta").on("click", function () {
                    var url = $url_crear_cuenta;

                    show_modal_cuenta(url);
                });
                
                $(".editar-cuenta").on("click", function () {
                    var id = $(this).attr("data-id-cuenta")
                    var url = `${$url_editar_cuenta}/${id}`

                    show_modal_cuenta(url);
                });
                
                $(".eliminar-cuenta").on("click", function () {
                    var eliminar = confirm("Esta seguro que desea eliminar esta cuenta?");
                    if (eliminar) {
                        var id = $(this).attr("data-id-cuenta")
                        var url$ = `${$url_eliminar_cuenta}/${id}`

                        eliminar_cuenta(url$);
                    }
                });

            },

            configure_editor: function () {
                var cuentaBancariaForm = document.getElementById("CuentaBancariaForm");
                cuentaBancariaForm.addEventListener("submit", guardarCuentaBancaria);

                $.validator.unobtrusive.parse(cuentaBancariaForm);
                !$(cuentaBancariaForm).valid();
            }
        }
    }
})()



document.addEventListener('DOMContentLoaded', function () {

    //-------------------------------
    // FORMATAÇÃO DO TELEFONE
    //-------------------------------
    const inputCelular = document.getElementById("CelularCatequista");

    inputCelular.addEventListener("input", function () {
        let valor = inputCelular.value.replace(/\D/g, "");

        if (valor.length > 11) valor = valor.slice(0, 11);

        if (valor.length >= 11) {
            valor = valor.replace(/^(\d{2})(\d{5})(\d{4})$/, "($1) $2-$3");
        } else if (valor.length >= 7) {
            valor = valor.replace(/^(\d{2})(\d{4})(\d{0,4})$/, "($1) $2-$3");
        } else if (valor.length >= 3) {
            valor = valor.replace(/^(\d{2})(\d{0,5})$/, "($1) $2");
        } else if (valor.length >= 1) {
            valor = valor.replace(/^(\d{0,2})$/, "($1");
        }

        inputCelular.value = valor;
    });


    //-------------------------------
    // VARIÁVEIS DO CROP
    //-------------------------------
    let cropper = null;

    const inputFoto = document.getElementById('inputFoto');
    const imagemParaRecorte = document.getElementById('imagemParaRecorte');
    const imagemFinal = document.getElementById('imagemFinal');
    const imagemRecortadaInput = document.getElementById('imagemRecortada');
    const modalEl = document.getElementById('cropModal');
    const confirmarCorteBtn = document.getElementById('confirmarCorte');



    //-------------------------------
    // 1) Carregar imagem original vinda do servidor
    //-------------------------------
    const fotoServidor = imagemFinal.dataset.foto;

    if (fotoServidor && fotoServidor.trim() !== "") {
        imagemFinal.src = fotoServidor;

        imagemFinal.onerror = function () {
            console.warn("Erro ao carregar a foto do servidor:", fotoServidor);
            imagemFinal.removeAttribute('src');
        };
    } else {
        imagemFinal.removeAttribute('src');
    }



    //-------------------------------
    // 2) Ao selecionar um arquivo → abrir cropper
    //-------------------------------
    inputFoto.addEventListener('change', function (e) {
        const file = e.target.files?.[0];
        if (!file) return;

        const reader = new FileReader();

        reader.onload = function (ev) {
            imagemParaRecorte.src = ev.target.result;

            const modal = new bootstrap.Modal(modalEl);
            modal.show();
        };

        reader.readAsDataURL(file);
    });



    //-------------------------------
    // 3) Inicializa Cropper quando o modal abrir
    //-------------------------------
    modalEl.addEventListener('shown.bs.modal', function () {

        if (cropper) {
            cropper.destroy();
            cropper = null;
        }

        cropper = new Cropper(imagemParaRecorte, {
            aspectRatio: 1,
            viewMode: 1,
            autoCropArea: 1,
            movable: true,
            zoomable: true,
            cropBoxMovable: true,
            cropBoxResizable: true
        });
    });



    //-------------------------------
    // 4) Confirmar corte → aplicar no preview + hidden
    //-------------------------------
    confirmarCorteBtn.addEventListener('click', function () {
        if (!cropper) return;

        const canvas = cropper.getCroppedCanvas({
            width: 150,
            height: 150
        });

        const base64Image = canvas.toDataURL('image/png');

        imagemRecortadaInput.value = base64Image;
        imagemFinal.src = base64Image;

        cropper.destroy();
        cropper = null;

        bootstrap.Modal.getInstance(modalEl).hide();
    });



    //-------------------------------
    // 5) Limpar cropper ao fechar modal
    //-------------------------------
    modalEl.addEventListener('hidden.bs.modal', function () {
        if (cropper) {
            cropper.destroy();
            cropper = null;
        }
    });

});

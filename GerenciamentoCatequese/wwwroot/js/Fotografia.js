let cropper;
const inputFoto = document.getElementById('inputFoto');
const imagemParaRecorte = document.getElementById('imagemParaRecorte');
const imagemFinal = document.getElementById('imagemFinal');

inputFoto.addEventListener('change', function (e) {
    const file = e.target.files[0];
    if (!file) return;

    const reader = new FileReader();
    reader.onload = function (event) {
        imagemParaRecorte.src = event.target.result;
        const modal = new bootstrap.Modal(document.getElementById('cropModal'));
        modal.show();

        // Espera a imagem carregar para iniciar o cropper
        imagemParaRecorte.onload = function () {
            cropper = new Cropper(imagemParaRecorte, {
                aspectRatio: 1, // 1:1 para recorte quadrado
                viewMode: 1,
                autoCropArea: 1,
            });
        };
    };
    reader.readAsDataURL(file);
});

const imagemRecortadaInput = document.getElementById('imagemRecortada');

document.getElementById('confirmarCorte').addEventListener('click', function () {
    if (cropper) {
        const canvas = cropper.getCroppedCanvas({
            width: 150,
            height: 150,
        });

        const base64Image = canvas.toDataURL('image/png');
        imagemRecortadaInput.value = base64Image;

        // Atualiza preview
        imagemFinal.src = base64Image;

        cropper.destroy();
        cropper = null;
        bootstrap.Modal.getInstance(document.getElementById('cropModal')).hide();
    }
});
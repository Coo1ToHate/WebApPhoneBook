var sel = document.querySelector("input[type='tel']");
var im = new Inputmask("8-999-999-99-99");
im.mask(sel);

new JustValidate('.form',
    {
        rules: {
            tel: {
                required: true,
                function: (name, value) => {
                    const phone = sel.inputmask.unmaskedvalue()
                    return Number(phone) && phone.length === 10
                }
            },
        },
    });

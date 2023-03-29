$(() => {
    let rowNumber = 1;
    $("#add-rows").on("click", function () {
        $("#ppl-rows").append(`<div class="row person-row" style="margin-bottom: 10px;">
            <div class="col-md-4">
                <input class="form-control" type="text" name="people[${rowNumber}].firstname" placeholder="First Name" />
            </div>
            <div class="col-md-4">
                <input class="form-control" type="text" name="people[${rowNumber}].lastname" placeholder="Last Name" />
            </div>
            <div class="col-md-4">
                <input class="form-control" type="text" name="people[${rowNumber}].age" placeholder="Age" />
            </div>
        </div>`)
        rowNumber++;
})
})
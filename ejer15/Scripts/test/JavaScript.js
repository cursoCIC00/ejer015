describe("A suite", function () {
    it("contains spec with an expectation", function () {
        expect(true).toBe(true);
    });

});
describe("Another suite", function () {
    var resultado;
    it("prueba de petición REST", function (done) {
        $.get("api/values/3", function (data) {
            resultado = data;
            done();
        });
    });
    afterEach(function (done) {
        expect(resultado).toBe("value");
        done();
    }, 1000);
});
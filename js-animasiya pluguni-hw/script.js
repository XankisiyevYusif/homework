anime({
  targets: "#box",
  translateX: 250,
});

var logEl = document.querySelector(".battery-log");

var battery = {
  charged: "0%",
  cycles: 120,
};

anime({
  targets: battery,
  charged: "100%",
  cycles: 130,
  round: 1,
  easing: "linear",
  update: function () {
    logEl.innerHTML = JSON.stringify(battery);
  },
});

anime({
  targets: ".loop",
  translateX: 270,
  loop: 3,
  easing: "easeInOutSine",
});

anime({
  targets: ".loop-infinity",
  translateX: 270,
  loop: true,
  easing: "easeInOutSine",
});

anime({
  targets: ".loop-reverse",
  translateX: 270,
  loop: 3,
  direction: "reverse",
  easing: "easeInOutSine",
});

anime({
  targets: ".loop-reverse-infinity",
  translateX: 270,
  direction: "reverse",
  loop: true,
  easing: "easeInOutSine",
});

anime({
  targets: ".loop-alternate",
  translateX: 270,
  loop: 3,
  direction: "alternate",
  easing: "easeInOutSine",
});

anime({
  targets: ".loop-alternate-infinity",
  translateX: 270,
  direction: "alternate",
  loop: true,
  easing: "easeInOutSine",
});

let gridContainer = document.querySelector(".staggering-grid-demo");
for (let i = 0; i < 67; i++) {
  let el = document.createElement("div");
  el.className = "el";
  gridContainer.appendChild(el);
}

anime({
  targets: ".staggering-grid-demo .el",
  scale: [
    { value: 0.1, easing: "easeOutSine", duration: 500 },
    { value: 1, easing: "easeInOutQuad", duration: 1200 },
  ],
  delay: anime.stagger(200, { grid: [14, 5], from: "center" }),
});

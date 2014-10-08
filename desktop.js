(function() {

  "use strict"

  // params

  var galleryLength = 20

  // init dom

  var shotArray = []
    , blurArray = []
    , shotList = document.createElement("ul")
    , blurWrap = document.createElement("div")
    , shotMask = document.createElement("div")
    , blurList = document.createElement("ul")
    , spinnerColors = ["#1AD6FD", "#1D62F0", "#C644FC", "#EF4DB6"]

  shotList.id = "shots"
  blurWrap.id = "blur"
  shotMask.id = "shotMask"

  function getRandomNumber(min, max) {
    return Math.round(Math.random() * (max - min) + min)
  }

  for (var i=0; i<galleryLength; i++) {

    var shotListItem = document.createElement("li")
      , blurListItem = document.createElement("li")
      , thumbPointerArea = document.createElement("span")
      , image = document.createElement("img")
      , blur = document.createElement("img")
      , spinner = document.createElement("span")

    thumbPointerArea.className = "thumbPointerArea"
    spinner.className = "spinner"
    spinner.style.borderColor = spinnerColors[getRandomNumber(0,4)]

    spinner.addEventListener("transitionend", function() {
      this.parentNode.removeChild(this)
    })

    shotListItem.appendChild(thumbPointerArea)
    shotListItem.appendChild(image)
    shotListItem.appendChild(spinner)
    blurListItem.appendChild(blur)

    shotArray.push(image)
    blurArray.push(blur)

    shotList.appendChild(shotListItem)
    blurList.appendChild(blurListItem)

  }

  blurWrap.appendChild(shotMask)
  blurWrap.appendChild(blurList)

  var fragment = document.createDocumentFragment()
  fragment.appendChild(shotList)
  if (devicePixelRatio > 1) {
    var cursor = document.createElement("span")
    cursor.id = "cursor"
    fragment.appendChild(cursor)
    shotList.addEventListener("mousemove", function(e) {
      cursor.style.top = e.clientY + "px"
      cursor.style.left = e.clientX + "px"
    })
  }
  fragment.appendChild(blurWrap)
  document.querySelector("main").appendChild(fragment)

  // api

  var worker = new Worker("js/worker.js")
  worker.postMessage("http://api.dribbble.com/players/bdc/shots?per_page=" + galleryLength)

  worker.addEventListener("message", function(e) { e.data.shots.forEach(function(shot, i) {

    var image = shotArray[i]
      , blur = blurArray[i]
      , shotURL = shot.image_url

    image.addEventListener("load", function() {
      this.className = "loaded"
      blur.src = shotURL
    })

    image.src = shotURL

  })})

  // basic tablet support

  if ("ontouchend" in window) {
    document.documentElement.addEventListener("touchend", function() {})
    document.documentElement.addEventListener("touchmove", function(e) {
      e.preventDefault()
    })
  }

})()
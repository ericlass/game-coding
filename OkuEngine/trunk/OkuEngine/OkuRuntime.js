// Actor class
function Actor(actorId) {
  this.actorId = actorId;

  this.getX = function() {
    return oku_getActorX(this.actorId);
  }

  this.getY = function() {
    return oku_getActorY(this.actorId);
  }

  this.setX = function(x) {
    oku_setActorX(this.actorId, x);
  }

  this.setY = function(y) {
    oku_setActorY(this.actorId, y);
  }

  this.getAngle = function() {
    return oku_getActorAngle(this.actorId);
  }

  this.setAngle = function(angle) {
    oku_setActorAngle(this.actorId, angle);
  }

  this.getState = function() {
    return oku_getActorState(this.actorId);
  }

  this.setState = function(state) {
    oku_setActorState(this.actorId, state);
  }

  this.getAttribute = function(name) {
    return oku_getActorAttribute(actorId, name);
  }

  this.setAttribute = function(name, value) {
    oku_setActorAttribute(this.actorId, name, value);
  }
  
}